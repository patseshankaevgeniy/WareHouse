import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { WAREHOUSE_API_BASE_URL, WareHouseAPIClient } from './clients/warehouse-api.client';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutComponent } from './pages/app-layout.component';
import { CommonModule, NgStyle } from '@angular/common';
import { DepartmentComponent } from './pages/department/department.component';
import { environment } from 'src/environments/environment';
import { NavigationBarModule } from './navigation-bar/navigation-bar.module';
import { WorkersComponent } from './pages/workers/worker.component';
import { ProductsComponent } from './pages/products/product.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AppLayoutComponent,
    DepartmentComponent,
    WorkersComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    NgStyle,
    AppRoutingModule,
    NavigationBarModule,
    FormsModule
  ],
  providers: [ 
    WareHouseAPIClient,
    {
      provide: WAREHOUSE_API_BASE_URL,
      useValue: environment.warehouseApiClientBaseUrl,
    }, ],
  bootstrap: [AppComponent]
})
export class AppModule { }
