import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { DishService } from 'src/app/services/dish.service';
import {FormBuilder, FormGroup, Validators, NgForm} from "@angular/forms";;

@Component({
  selector: 'app-edit-dish',
  templateUrl: './edit-dish.component.html',
  styleUrls: ['./edit-dish.component.css']
})
export class EditDishComponent implements OnInit {
  dishForm:FormGroup;
  id:number;
  restaurantId:number;
  imagePath:String;
  constructor(private formBuilder: FormBuilder, private activatedRoute: ActivatedRoute, private router: Router, private dishService:DishService) { }

  ngOnInit() {
    this.getDetail(this.activatedRoute.snapshot.params['id'],this.activatedRoute.snapshot.params['idDish']);
 
    this.dishForm = this.formBuilder.group({
      id:['', Validators.compose([Validators.required])],
      name: ['', Validators.compose([Validators.required])],
      mainIngredient: ['', Validators.compose([Validators.required])],
      nationality: ['', Validators.compose([Validators.required])],
      cost: ['', Validators.compose([Validators.required])],
      size: ['', Validators.compose([Validators.required])],
      imagePath: ['', Validators.compose([Validators.required])],
      restaurantId: ['', Validators.compose([Validators.required])]
    });
  }

  getDetail(idRestaurant:number, idDish:number) {
    this.dishService.getDish(idRestaurant, idDish)
      .subscribe(dish => {
        this.id = dish.id;
        this.restaurantId = dish.restaurantId;
        this.dishForm.setValue({
          id: dish.id,
          name: dish.name,
          mainIngredient: dish.mainIngredient,
          nationality: dish.nationality,
          cost: dish.cost,
          size: dish.size,
          imagePath: dish.imagePath,
          restaurantId: dish.restaurantId          
        });
        console.log(dish);
        this.imagePath = dish.imagePath;
      });
  }

  
  onSubmit(form:NgForm) {
    this.dishService.putDish(form, this.restaurantId)
      .subscribe(res => {
          this.router.navigate([`/restaurants/${this.restaurantId}/dishes`]);
        }
      );
  }

  onClick() {
    console.log("asd");
    this.router.navigate([`/restaurants/${this.restaurantId}/dishes`]);
  }
}
