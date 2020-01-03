import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Dish } from 'src/app/models/dish';
import { DishService } from 'src/app/services/dish.service';

@Component({
  selector: 'app-dish-item',
  templateUrl: './dish-item.component.html',
  styleUrls: ['./dish-item.component.css']
})
export class DishItemComponent implements OnInit {
  @Input() dish:Dish;

  constructor() { }

  ngOnInit() {
  }

}
