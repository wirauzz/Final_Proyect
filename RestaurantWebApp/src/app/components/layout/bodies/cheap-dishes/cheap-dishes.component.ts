import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { DishService } from 'src/app/services/dish.service';
import { Restaurant } from 'src/app/models/restaurant';
import { Dish } from 'src/app/models/dish';

@Component({
  selector: 'app-cheap-dishes',
  templateUrl: './cheap-dishes.component.html',
  styleUrls: ['./cheap-dishes.component.css']
})
export class CheapDishesComponent implements OnInit {
  restaurants:Restaurant[];
  dishes:Dish[];

  constructor(private restaurantService:RestaurantService, private dishService:DishService) { }

  ngOnInit() {
    this.restaurantService.getRestaurants().subscribe(restaurants => {
      this.restaurants = restaurants; 
      this.restaurants.forEach(restaurant => {
        this.dishService.getDishes(restaurant.id).subscribe( dishes => {
          this.dishes = dishes;
          this.dishes.sort(function(a, b) {
            if (a.cost > b.cost) {
                return -1;
            }
            if (b.cost > a.cost) {
                return 1;
            }
            return 0;
            })
            
          restaurant.dishes.push(
            this.dishes[this.dishes.length-1]
          );
        });
  
      });
    });

  }

}
