import { Injectable } from '@angular/core';
import { Restaurant } from "src/app/models/restaurant";

@Injectable({
  providedIn: 'root'
})
export class SharingService{
  private restaurant:Restaurant = undefined;

  setData(restaurant:Restaurant){
      this.restaurant = restaurant;
  }

  getData():Restaurant{
      return this.restaurant;
  }
}