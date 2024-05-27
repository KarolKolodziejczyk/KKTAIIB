import { Component } from '@angular/core';
import { ProductDTO } from '../models/product.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent {
  public product!: ProductDTO;

  public productRequest: ProductDTO = {
    name: '',
    price: 0,
    image: '',
    isActive: true,
    id: 0
  };

  constructor(private route: ActivatedRoute, private productService: ProductsService, private router: Router ) {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      console.log('Product ID:', id); // Dodaj to logowanie
      if (id !== null) {
        this.productService.getProductById(parseInt(id)).subscribe({
          next: (product) => {
            this.product = product;
            this.productRequest = product;
          },
          error: (err) => console.error(err)
        });
      }
    });
  }
  
  

  
 public onSubmit(event: any): void {
    /*if (this.product != undefined) {
      if (event.submitter && event.submitter.name === 'delete') {
        this.productService.delete(this.product.id).subscribe({
          next: () => {
            this.router.navigate([`/products`]);
          },
          error: (err) => console.error(err)
        })
      }
      else if (event.submitter && event.submitter.name === 'changeState') {
        this.productService.changeActiveState(this.product.id).subscribe({
          next: () => {
            this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
              this.router.navigate([`/products/${this.product.id}`]);
            })
          },
          error: (err) => console.error(err)
        })
      }
      else if (event.submitter && event.submitter.name === 'save') {
        this.productService.update(this.product.id, this.productRequest).subscribe({
          next: () => {
            this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
              this.router.navigate([`/products/${this.product.id}`]);
            })
          },
          error: (err) => console.error(err)
        })
      }
    }
    */
  }

  public cancel(): void{
    this.productService.changeActiveState(this.product.id, false).subscribe({
      next: () => {
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.router.navigate([`/products/${this.product.id}`]);
        })
      },
      error: (err) => console.error(err)
    })
  }
}