import { Component, OnInit } from '@angular/core';
import { DishService } from 'src/app/services/dish.service';
import { Dish } from 'src/app/models/dish';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-dishes',
  templateUrl: './dishes.component.html',
  styleUrls: ['./dishes.component.css']
})
export class DishesComponent implements OnInit {
  dishes:Dish[];
  idRestaurant:number;

  constructor(private dishService:DishService, private route:ActivatedRoute) {}

  ngOnInit() {
    this.route.params.subscribe( params => this.dishService.getDishes(params['id']).subscribe(dishes => {
      this.dishes = dishes
    }));
  }

  addDish(dish:Dish) { 
    this.dishService.addDish(dish, this.idRestaurant).subscribe(dish => {
      this.dishes.push(dish);
    });
  }

  editDish(dish:Dish) {
    this.dishService.putDish(dish,this.idRestaurant).subscribe(dish => {
      this.dishes[this.dishes.findIndex(d => d.id == dish.id)] = dish;
    })
  }

  deleteDish(dish:Dish) {
    this.dishes = this.dishes.filter(d => d.id != dish.id);
    this.dishService.deleteDish(dish, this.idRestaurant).subscribe();
  }
}
