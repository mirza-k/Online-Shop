import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product/product.model';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-admin-product-item',
  templateUrl: './admin-product-item.component.html',
  styleUrls: ['./admin-product-item.component.css']
})
export class AdminProductItemComponent implements OnInit {
  @Input() productItem!: Product;
  @Input() currentPage!: number;
  @Input() numberOfItems!: number;


  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
  }

  onDelete(id: string) {
    this.productService.delete(id, this.currentPage, this.numberOfItems);
  }

  onUpdate(id: string) {
    this.router.navigate([`/product/update/${id}`]);
  }
}
