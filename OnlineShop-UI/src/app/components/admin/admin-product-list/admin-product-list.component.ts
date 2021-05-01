import { Component, OnInit } from '@angular/core';

import { ProductService } from 'src/app/services/product/product.service';
import { Product } from '../../../models/product/product.model';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit {
  products!: Product[];
  numberOfItems = 7;
  currentPage = 1;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.get(this.currentPage,this.numberOfItems).subscribe((res: Product[]) => {
      this.products = res;
      this.productService.productsChanged.subscribe(data => {
        this.products = data;
      })
    })
  }

  pageNumberChange(data: any) {
    this.productService.get(this.currentPage,this.numberOfItems).subscribe((res:Product[])=>{
      this.products = res;
    })
    window.scroll(0,0);
  }

}
