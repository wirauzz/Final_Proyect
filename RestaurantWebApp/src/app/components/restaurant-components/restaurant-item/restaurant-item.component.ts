import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { Router } from '@angular/router';
import { SharingService } from '../../../services/sharing.service';


@Component({
  selector: 'app-restaurant-item',
  templateUrl: './restaurant-item.component.html',
  styleUrls: ['./restaurant-item.component.css']
})
export class RestaurantItemComponent implements OnInit {
  @Input() restaurant:Restaurant;
  @Output() deleteRestaurant:EventEmitter<Restaurant> = new EventEmitter();
  @Output() getDishesFromRestaurant:EventEmitter<Restaurant> = new EventEmitter();

  constructor(private router:Router, private sharingService:SharingService) { }

  ngOnInit() {
  }

  onDelete(restaurant) {
    this.deleteRestaurant.emit(restaurant);
  }

  onRedirect(restaurant) { 
    console.log("I got clicked!!");
    this.sharingService.setData(restaurant);
    this.router.navigate(["/dishes"]);//redirects url to new component
  }


}
