import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product/product.model';

import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() productItem!: Product;

  ngOnInit(): void {
  }
}
