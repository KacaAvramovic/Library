import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import * as Book from '../models/Book';
import * as Author from '../models/Author';
import * as Genre from '../models/Genre';
import { forkJoin, Observable } from 'rxjs';


@Component({
  selector: 'app-book-component',
  templateUrl: './book.component.html',
  styles: ['./book.component.css']
})
export class BookComponent implements  OnInit {

  error = '';
  genres: Genre[];
  authors: Author[];
  bookId: number;

  constructor(private http: HttpClient,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) {

    this.http = http;
  }

  ngOnInit(): void {

    let getGeners = this.http.get(environment.apiUrl + 'Genres');
    let getAuthors = this.http.get(environment.apiUrl + 'Authors');

    forkJoin([getGeners, getAuthors]).subscribe(([genres, authors]: [Genre[], Author[]]) => {
      this.genres = genres;
      this.authors = authors;

      this.setBook();
    });
  }

  bookForm = this.fb.group({
    id: -1,
    title: ['', Validators.required],
    author: this.fb.group({
      id: 0,
      name: ''
    }),
    genre: this.fb.group({
      id: 0,
      name: ''
    }),
    description: ['', Validators.required]
  });

  setBook() {
    this.route.queryParams.subscribe((params) => {
      if (params['id']) {
        this.bookId = params['id'];
        this.http.get<Book>(environment.apiUrl + 'Books/' + this.bookId).subscribe(
          (response) => {
            this.bookForm.patchValue(response);
            this.bookForm.controls['author'].patchValue(response.author);
            this.bookForm.controls['genre'].patchValue(response.genre);
          },
          (error) => {
            this.error = error.message;
          }
        )
      }
    });
  }

  onSubmit() {

    var book = {
      "id": this.bookForm.value.id,
      "title": this.bookForm.value.title,
      "description": this.bookForm.value.description,
      "genre": this.bookForm.value.genre.id,
      "author": this.bookForm.value.author.id
    };

    if (book.id === -1) {
      this.http.post(environment.apiUrl + 'Books', book).subscribe(
        (response) => {
          this.backToLibrary();
        },
        (error) => {
          this.error = error.message;
        }
      )
    }
    else {
      this.http.put(environment.apiUrl + 'Books/' + this.bookId, book).subscribe(
        (response) => {
          this.error = '';
          this.backToLibrary();
        },
        (error) => {
          this.error = error.message;
        }
      )
    }
  }

  cancel() {
    this.backToLibrary();
  }

  changeAuthor(authorId) {
    var author = this.authors.find(x => x.id == authorId);
    this.bookForm.controls['author'].patchValue({ name: author.name, id: authorId});
  }

  changeGenre(genreId) {
    var genre = this.genres.find(x => x.id == genreId);
    this.bookForm.controls['genre'].patchValue({ name: genre.name, id: genreId });
  }

  backToLibrary() {
    this.router.navigate(['/library']);
  }
}
