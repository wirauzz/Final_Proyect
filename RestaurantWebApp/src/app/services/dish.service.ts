import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Dish } from '../models/dish';
import { Restaurant } from '../models/restaurant';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}


@Injectable({
  providedIn: 'root'
})
export class DishService {
  dishUrl:string = 'https://localhost:44347/api/Restaurant';
  constructor(private Http:HttpClient) { }

  //get restaurants

  getDishes(idRestaurant:number):Observable<Dish[]> {
    return this.Http.get<Dish[]>(`${this.dishUrl}/${idRestaurant}/Dish`);
  }

  deleteDish(dish:Dish,idRestaurant:number):Observable<any> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish/${dish.id}`;
    return this.Http.delete(url, httpOptions);
  }
  
  addDish(dish:Dish,idRestaurant:number):Observable<Dish> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish`;
    return this.Http.post<Dish>(this.dishUrl,dish,httpOptions); 
  }

  putDish(dish:Dish,idRestaurant:number):Observable<Dish> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish/${dish.id}`;
    return this.Http.put<Dish>(url,dish,httpOptions); 
  }
}
