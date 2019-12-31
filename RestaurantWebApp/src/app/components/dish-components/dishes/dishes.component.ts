import { Component, OnInit } from '@angular/core';
import { DishService } from 'src/app/services/dish.service';
import { Dish } from 'src/app/models/dish';


@Component({
  selector: 'app-dishes',
  templateUrl: './dishes.component.html',
  styleUrls: ['./dishes.component.css']
})
export class DishesComponent implements OnInit {
  dishes:Dish[];
  constructor(private dishService:DishService) { }

  ngOnInit() {
    this.dishService.getDishes(2).subscribe(dishes => {
      this.dishes = dishes;
    });
  }

  addDish(dish:Dish) { 
    this.dishService.addDish(dish, dish.restaurantId).subscribe(dish => {
      this.dishes.push(dish);
    });
  }

  editDish(dish:Dish) {
    this.dishService.putDish(dish,dish.restaurantId).subscribe(dish => {
      this.dishes[this.dishes.findIndex( d => d.id = dish.id)] = dish;
    })
  }

}
