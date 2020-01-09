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
  dishUrl:string = 'https://localhost:44347/api/Restaurant';
  constructor(private Http:HttpClient) { }

  //get restaurants

  getDishes(idRestaurant:number):Observable<Dish[]> {
    return this.Http.get<Dish[]>(`${this.dishUrl}/${idRestaurant}/Dish`);
  }

  getDish(idRestaurant:number,idDish:Number):Observable<Dish> {
    return this.Http.get<Dish>(`${this.dishUrl}/${idRestaurant}/Dish/${idDish}`);
  }

  deleteDish(dish:Dish,idRestaurant:number):Observable<any> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish/${dish.id}`;
    return this.Http.delete(url, httpOptions);
  }
  
  addDish(dish,idRestaurant:number):Observable<Dish> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish`;
    return this.Http.post<Dish>(url,dish,httpOptions); 
  }

  putDish(dish,idRestaurant:number):Observable<Dish> {
    const url = `${this.dishUrl}/${idRestaurant}/Dish/${dish.id}`;
    return this.Http.put<Dish>(url,dish,httpOptions); 
  }
}
