import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantItemComponent } from './components/restaurant-components/restaurant-item/restaurant-item.component';
import { RestaurantsComponent } from './components/restaurant-components/restaurants/restaurants.component';
import { DishesComponent } from './components/dish-components/dishes/dishes.component';
import { DishItemComponent } from './components/dish-components/dish-item/dish-item.component';
import { AddRestaurantComponent } from './components/restaurant-components/add-restaurant/add-restaurant.component';
import { EditRestaurantComponent } from './components/restaurant-components/edit-restaurant/edit-restaurant.component';
import { HeaderComponent } from './components/layout/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantItemComponent,
    RestaurantsComponent,
    DishesComponent,
    DishItemComponent,
    AddRestaurantComponent,
    EditRestaurantComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
