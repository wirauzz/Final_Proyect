import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Restaurant } from '../models/restaurant';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}



@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  restaurantUrl:string = 'https://localhost:44347/api/Restaurant';
  currentRestaurant:Restaurant;
  constructor(private Http:HttpClient) { }

  getRestaurants():Observable<Restaurant[]> {
    return this.Http.get<Restaurant[]>(`${this.restaurantUrl}`);
  }

  getRestaurant(idRestaurant:number):Observable<Restaurant> {
    return this.Http.get<Restaurant>(`${this.restaurantUrl}/${idRestaurant}`);
  }

  deleteRestaurant(restaurant:Restaurant):Observable<any> {
    const url = `${this.restaurantUrl}/${restaurant.id}`;
    return this.Http.delete(url, httpOptions);
  }
  
  /*updateRestaurant(restaurant:Restaurant):Observable<any> { 
    const url = `${this.restaurantUrl}/${restaurant.id}`;
    return this.Http.put(url, restaurant);
  }*/
  
  addRestaurant(restaurant):Observable<Restaurant> {
    return this.Http.post<Restaurant>(this.restaurantUrl,restaurant,httpOptions); 
  }

  putRestaurant(restaurant):Observable<Restaurant> {
    const url = `${this.restaurantUrl}/${restaurant.id}`;
    return this.Http.put<Restaurant>(url,restaurant,httpOptions); 
  }

}


