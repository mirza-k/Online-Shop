import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'
import { ActivatedRoute } from '@angular/router';

import { Brand } from 'src/app/models/product/brand.model';
import { Category } from 'src/app/models/product/category.model';
import { Color } from 'src/app/models/product/color.model';
import { genderCategory } from 'src/app/models/product/genderCategory.model';
import { Product } from 'src/app/models/product/product.model';
import { subCategory } from 'src/app/models/product/subCategory.model';
import { BrandService } from 'src/app/services/product/brand.service';
import { CategoryService } from 'src/app/services/product/category.service';
import { ColorService } from 'src/app/services/product/color.service';
import { GenderCategoryService } from 'src/app/services/product/gender-category.service';
import { ProductService } from 'src/app/services/product/product.service';
import { SubCategoryService } from 'src/app/services/product/sub-category.service';

@Component({
  selector: 'app-admin-add-product',
  templateUrl: './admin-add-product.component.html',
  styleUrls: ['./admin-add-product.component.css']
})
export class AdminAddProductComponent implements OnInit {
  addProductForm!: FormGroup;
  updatedProduct!: Product;

  categories: Category[] = [];
  brands: Brand[] = [];
  genderCategories: genderCategory[] = [];
  colors: Color[] = [];
  subCategories: subCategory[] = [];

  constructor(private categoryService: CategoryService, private brandSevice: BrandService, private genderCategory: GenderCategoryService,
    private colorService: ColorService, private subCategoryService: SubCategoryService, private productService: ProductService,
    private route: ActivatedRoute) { }


  ngOnInit(): void {
    this.categoryService.get().subscribe((res: Category[]) => {
      this.categories = res;
    });

    this.brandSevice.get().subscribe((res: Brand[]) => {
      this.brands = res;
    });

    this.genderCategory.get().subscribe((res: genderCategory[]) => {
      this.genderCategories = res;
    });

    this.colorService.get().subscribe((res: Color[]) => {
      this.colors = res;
    });


    var updateProductId = this.route.snapshot.params['id'];
    if (updateProductId != null) {

      this.productService.getById(updateProductId).subscribe((res: Product) => {
        this.updatedProduct = res;

        //fetch data for products categoryId
        this.subCategoryService.getById(this.updatedProduct.categoryId).subscribe((res: subCategory[]) => {
          this.subCategories = res;
        });
  

        this.addProductForm = new FormGroup({
          'name': new FormControl(this.updatedProduct.name),
          'itemPrice': new FormControl(this.updatedProduct.itemPrice),
          'imageUrl': new FormControl(this.updatedProduct.imageUrl),
          'stockQuantity': new FormControl(this.updatedProduct.stockQuantity),
          'description': new FormControl(this.updatedProduct.description),
          'categoryId': new FormControl(this.updatedProduct.categoryId),
          'brandId': new FormControl(this.updatedProduct.brandId),
          'genderCategoryId': new FormControl(this.updatedProduct.genderCategoryId),
          'colorId': new FormControl(this.updatedProduct.colorId),
          'subCategoryId': new FormControl(this.updatedProduct.subCategoryId),
          'productId': new FormControl(this.updatedProduct.productId)
        })
      });

    }
    else {

      //fetch data for default category by categoryId = 1
      this.subCategoryService.getById(1).subscribe((res: subCategory[]) => {
        this.subCategories = res;
      });

      this.addProductForm = new FormGroup({
        'name': new FormControl(null),
        'itemPrice': new FormControl(null),
        'imageUrl': new FormControl(null),
        'stockQuantity': new FormControl(null),
        'description': new FormControl(null),
        'categoryId': new FormControl(1),
        'brandId': new FormControl(1),
        'genderCategoryId': new FormControl(1),
        'colorId': new FormControl(1),
        'subCategoryId': new FormControl(1),
        'productId': new FormControl('bb8e6b8c-c4e0-490d-85e6-b5bc48146939')
      });
    }
  }

  onChange(data: any) {
    var categoryId = data.value.charAt(data.value.length - 1);
    var firstSubCategoryId = 0;

    //fetch data from subcategories with categoryId
    this.subCategoryService.getById(categoryId).subscribe((res: subCategory[]) => {
      this.subCategories = res;

      firstSubCategoryId = res[0].subCategoryId

      //set default value 
      this.addProductForm.get('subCategoryId')?.patchValue(firstSubCategoryId);
    });
  }

  onSubmit() {
    var newProduct: Product = this.addProductForm.value;
    
    if (this.updatedProduct != null) {

      this.productService.update(newProduct.productId, newProduct).subscribe(res=>{
        alert("Product updated.");
      })
    } else{
      this.productService.post(newProduct).subscribe(res => {
        alert("Product added.");
      })
    }
  }

}
