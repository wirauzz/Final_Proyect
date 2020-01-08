import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { Router } from '@angular/router';


@Component({
  selector: 'app-restaurant-item',
  templateUrl: './restaurant-item.component.html',
  styleUrls: ['./restaurant-item.component.css']
})
export class RestaurantItemComponent implements OnInit {
  @Input() restaurant:Restaurant;
  @Output() deleteRestaurant:EventEmitter<Restaurant> = new EventEmitter();
  @Output() getDishesFromRestaurant:EventEmitter<Restaurant> = new EventEmitter();

  constructor(private router:Router) { }

  ngOnInit() {
  }

  onDelete(restaurant:Restaurant) {
    this.deleteRestaurant.emit(restaurant);
  }

  onEdit(restaurant:Restaurant) {
    this.router.navigate([`/restaurants/edit/${restaurant.id}`]);
  }

  onRedirect(restaurant) { 
    this.router.navigate([`/restaurants/${restaurant.id}/dishes`]);
  }


}
