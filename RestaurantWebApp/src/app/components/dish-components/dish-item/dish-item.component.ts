import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Dish } from 'src/app/models/dish';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dish-item',
  templateUrl: './dish-item.component.html',
  styleUrls: ['./dish-item.component.css']
})
export class DishItemComponent implements OnInit {
  @Input() dish:Dish;
  @Output() deleteDish:EventEmitter<Dish> = new EventEmitter();

  constructor(private router:Router) { }

  ngOnInit() {
  }

  onDelete(dish:Dish) {
    this.deleteDish.emit(dish);
  }

  onRedirect(dish:Dish) {
    console.log(dish);
    this.router.navigate([`/restaurants/${dish.restaurantId}/dishes/edit/${dish.id}`]);
  }


}
