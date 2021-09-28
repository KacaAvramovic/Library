import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import * as Book from '../models/Book';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html'
})
export class LibraryComponent implements OnInit{
  public books: Book[];
  http: HttpClient;
  error: string;
 
  constructor(
    http: HttpClient,
    private route: ActivatedRoute,
    private router: Router) {

      this.http = http;
  }

  ngOnInit(): void {
    this.getAllBooks();
  }

  public addBook() {
    this.router.navigate(['/book']);
  }

  public editBook(bookId) {
    this.router.navigate(['/book'], { queryParams: { id: bookId } });
  }

  public getAllBooks() {
    this.http.get<Book[]>(environment.apiUrl + 'Books').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }

  public deleteBook(bookId) {
    if (confirm('Are you sure you want to delete the book?')) {
      this.http.delete(environment.apiUrl + 'Books/' + bookId).subscribe(
        (response) => {
          this.error = '';
          this.getAllBooks();
        },
        (error) => {
          this.error += error.message;
        }
      )
    } 
  }
}
