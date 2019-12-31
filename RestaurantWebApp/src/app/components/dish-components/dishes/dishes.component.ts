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

}
