import { Component } from '@angular/core';
import { ProductDTO } from '../models/product.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public data: ProductDTO[] = [];
  public page: number = 1;
  public count: number = 5;
  constructor(private productsService: ProductsService, private router: Router) {
    this.getData();
  }
  private getData(): void {
    this
    this.productsService.get({ count: this.count, page: this.page }).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
}

