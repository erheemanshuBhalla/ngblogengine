
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../environments/environment.development';
import { catchError, throwError } from 'rxjs';

import { Injectable, PipeTransform } from '@angular/core';

import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

import { Product } from '../Interface/Products';
import { PRODUCTDATA } from '../Data/ProductData';
import { DecimalPipe } from '@angular/common';
import { debounceTime, delay, switchMap, tap, toArray } from 'rxjs/operators';
import { SortColumn, SortDirection } from '../directives/table-sortable.directive';

interface SearchResult {
  countries: Product[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: SortColumn;
  sortDirection: SortDirection;
}
const compare = (v1: string | number | boolean, v2: string | number | boolean) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(countries: Product[], column: SortColumn, direction: string): Product[] {
  console.log("sort");

  if (direction === '' || column === '') {
    console.log("33");
    return countries;
  } else {
    console.log("37");
    return [...countries].sort((a, b) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(country: Product, term: string, pipe: PipeTransform) {
  //console.log("matches");
  //console.log(country);
  //console.log("matches");
  
  return (
    country.name.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(country.name).includes(term) ||
    pipe.transform(country.price).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  pipe!: DecimalPipe;
  readonly BaseURI = environment.apiuUrl
  //Products!: Observable<any[]>; 
  Products1!: any[]; 
  ObjData: Observable<Product[]>;
  PRODUCTDATA1: Product[] = [];

  ObjData1!: Observable<Product[]>;
  PRODUCTDATA2: Product[] = [];
  constructor(private http: HttpClient) {
    this._search$
      .pipe(
        tap(() => this._loading$.next(true)),
        debounceTime(200),
        switchMap(() => this._search()),
        delay(200),
        tap(() => this._loading$.next(false)),
      )
      .subscribe((result) => {
        this._countries$.next(result.countries);
        this._total$.next(result.total);
      });

    
    
    this.ObjData =this.http.get<Product[]>(this.BaseURI + '/Product');
    this.ObjData.pipe(toArray()).subscribe(array => {

      //console.log(array);
      this.PRODUCTDATA1 = array[0]; // Output: [1, 2, 3, 4, 5]
      this._search$.next();
    });
    
    
  }


  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(this.BaseURI +'/ProductCategory');
  }
  //this.categoryId, this.AmberMax, this.GreenMin, this.selected_colors, this.selected_sizes
  getProducts(categoryid: number,max_price:number,min_price:number,colors:any,sizes:any): Observable<any[]> {
    //console.log(id);
    const apiUrl = this.BaseURI + '/Search/';
    console.log(apiUrl);
    const data = {
      categoryid: categoryid,
      min_price: min_price,
      max_price: max_price,
      colors: colors,
      sizes:sizes
    };
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this.ObjData1 = this.http.post<Product[]>(this.BaseURI + '/Search', data);
    //this.ObjData1 = this.http.post<Product[]>(this.BaseURI + '/Product');
    /*this.ObjData1.pipe(toArray()).subscribe(array => {
      //console.log(array);
      this.PRODUCTDATA2 = array[0]; // Output: [1, 2, 3, 4, 5]
    });*/
    return this.ObjData1;
  }

  get_Products_component(id:string): Observable<any[]> {
    //console.log(id);
    const apiUrl = this.BaseURI + '/Search/'+id;
    console.log(apiUrl);
    
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this.ObjData1 = this.http.get<Product[]>(apiUrl);
    
    return this.ObjData1;
  }
  getProductDetails(id: number | null): any {
    return this.http.get<any>(this.BaseURI + '/Product/'+id);
  }
  updateProduct(id: number | null, Product: any) {
    //console.log(id);
    //console.log(Product);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http
      .put(this.BaseURI + '/Product/' + id, Product, { headers })
      .pipe(
        catchError((error) => {
          console.error('Error editing product:', error);
          return throwError(() => error);
        })
      );
  }
  saveProduct(Product: any) {
    return this.http.post(this.BaseURI + '/Product', Product);
  }

  /* Sorting */
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _countries$ = new BehaviorSubject<Product[]>([]);
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: '',
  };

  get countries$() {
    return this._countries$.asObservable();
  }
  get total$() {
    return this._total$.asObservable();
  }
  get loading$() {
    return this._loading$.asObservable();
  }
  get page() {
    return this._state.page;
  }
  get pageSize() {
    return this._state.pageSize;
  }
  get searchTerm() {
    return this._state.searchTerm;
  }

  set page(page: number) {
    this._set({ page });
  }
  set pageSize(pageSize: number) {
    this._set({ pageSize });
  }
  set searchTerm(searchTerm: string) {
    this._set({ searchTerm });
  }
  set sortColumn(sortColumn: SortColumn) {
    this._set({ sortColumn });
  }
  set sortDirection(sortDirection: SortDirection) {
    this._set({ sortDirection });
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;
    //debugger;
   // console.log("170");
    //console.log(this.Products1);
    // 1. sort
    let countries = sort(this.PRODUCTDATA1, sortColumn, sortDirection);
    //console.log("174");
   // console.log(countries);
    // 2. filter
    countries = countries.filter((country) => matches(country, searchTerm, this.pipe));
    const total = countries.length;

    // 3. paginate
    countries = countries.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ countries, total });
  }
  /*sorting*/

}
