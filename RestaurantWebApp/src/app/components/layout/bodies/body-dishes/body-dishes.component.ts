import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';

@Component({
  selector: 'app-body-dishes',
  templateUrl: './body-dishes.component.html',
  styleUrls: ['./body-dishes.component.css']
})
export class BodyDishesComponent implements OnInit {
  restaurant:Restaurant;
  constructor() { }

  ngOnInit() {
    setTimeout(()=>{ this.restaurant = JSON.parse(localStorage.getItem("restaurant"))}, 100);  
  }

}
