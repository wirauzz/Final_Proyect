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
import { DishesPageComponent } from './components/pages/dishes-page/dishes-page.component';
import { RestaurantsPageComponent } from './components/pages/restaurants-page/restaurants-page.component';
import { AddDishComponent } from './components/dish-components/add-dish/add-dish.component';
import { EditDishComponent } from './components/dish-components/edit-dish/edit-dish.component';
import { HomeComponent } from './components/layout/bodies/home/home.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { BodyDishesComponent } from './components/layout/bodies/body-dishes/body-dishes.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantItemComponent,
    RestaurantsComponent,
    DishesComponent,
    DishItemComponent,
    AddRestaurantComponent,
    EditRestaurantComponent,
    HeaderComponent,
    DishesPageComponent,
    RestaurantsPageComponent,
    AddDishComponent,
    EditDishComponent,
    HomeComponent,
    FooterComponent,
    HomePageComponent,
    BodyDishesComponent
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
