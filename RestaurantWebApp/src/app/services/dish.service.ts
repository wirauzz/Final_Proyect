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

  getDishes(restaurant:Restaurant):Observable<Dish[]> {
    return this.Http.get<Dish[]>(`${this.dishUrl}/${restaurant.id}/Dish`);
  }

  deleteDish(dish:Dish,restaurant:Restaurant):Observable<any> {
    const url = `${this.dishUrl}/${restaurant.id}/Dish/${dish.id}`;
    return this.Http.delete(url, httpOptions);
  }
  
  addDish(dish:Dish,restaurant:Restaurant):Observable<Dish> {
    const url = `${this.dishUrl}/${restaurant.id}/Dish`;
    return this.Http.post<Dish>(this.dishUrl,dish,httpOptions); 
  }

  putDish(dish:Dish,restaurant:Restaurant):Observable<Dish> {
    const url = `${this.dishUrl}/${restaurant.id}/Dish/${dish.id}`;
    return this.Http.put<Dish>(url,dish,httpOptions); 
  }
}
