import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-add-restaurant',
  templateUrl: './add-restaurant.component.html',
  styleUrls: ['./add-restaurant.component.css']
})
export class AddRestaurantComponent implements OnInit {
  @Output() addRestaurant: EventEmitter<any> = new EventEmitter();
  name:string;
  foodStyle:string;
  street:string;
  addressNumber:number;
  imagePath:string;
  constructor(private activeAouter: ActivatedRoute, private router: Router, private restaurantService:RestaurantService) { }

  ngOnInit() {
  }
  
  onSubmit() {
    const restaurant = {
      name: this.name,
      foodStyle: this.foodStyle,
      street: this.street,
      addressNumber: this.addressNumber,
      imagePath:this.imagePath
    }
    this.restaurantService.addRestaurant(restaurant).subscribe( res => {
      this.router.navigate(['/']);
        });
  }

}
