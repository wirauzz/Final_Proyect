import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Dish } from '../models/dish';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}


@Injectable({
  providedIn: 'root'
})
export class DishService {
  dishUrl:string = 'http://jsonplaceholder.typicode.com/posts';
  constructor(private Http:HttpClient) { }
}
