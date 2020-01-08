import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import {FormBuilder, FormGroup, Validators, NgForm} from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-restaurant',
  templateUrl: './edit-restaurant.component.html',
  styleUrls: ['./edit-restaurant.component.css']
})
export class EditRestaurantComponent implements OnInit {
  restaurantForm:FormGroup;
  id:number;
  imagePath:String;
  constructor(private formBuilder: FormBuilder, private activeAouter: ActivatedRoute, private router: Router, private restaurantService:RestaurantService) { }

  ngOnInit() {
    this.getDetail(this.activeAouter.snapshot.params['id']);
 
    this.restaurantForm = this.formBuilder.group({
      id:['', Validators.compose([Validators.required])],
      name: ['', Validators.compose([Validators.required])],
      foodStyle: ['', Validators.compose([Validators.required])],
      street: ['', Validators.compose([Validators.required])],
      addressNumber: ['', Validators.compose([Validators.required])],
      imagePath: ['', Validators.compose([Validators.required])]
    });
  }
  getDetail(id) {
    this.restaurantService.getRestaurant(id)
      .subscribe(restaurant => {
        this.id = restaurant.id;
        this.restaurantForm.setValue({
          id: restaurant.id,
          name: restaurant.name,
          foodStyle: restaurant.foodStyle,
          street: restaurant.street,
          addressNumber: restaurant.addressNumber,
          imagePath: restaurant.imagePath
        });
        console.log(restaurant);
        this.imagePath = restaurant.imagePath;
      });
  }

  onSubmit(form:NgForm) {
    this.restaurantService.putRestaurant(form)
      .subscribe(res => {
          this.router.navigate(['/']);
        }
      );
  }


}
