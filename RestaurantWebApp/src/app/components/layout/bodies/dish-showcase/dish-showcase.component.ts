import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { DishService } from 'src/app/services/dish.service';
import { Restaurant } from 'src/app/models/restaurant';
import { Dish } from 'src/app/models/dish';

@Component({
  selector: 'app-dish-showcase',
  templateUrl: './dish-showcase.component.html',
  styleUrls: ['./dish-showcase.component.css']
})
export class DishShowcaseComponent implements OnInit {
  restaurants:Restaurant[];
  dish:Dish;

  constructor(private restaurantService:RestaurantService, private dishService:DishService) { }

  ngOnInit() {
    this.restaurantService.getRestaurants().subscribe(restaurants => {
      this.restaurants = restaurants;
    });
  }

}
