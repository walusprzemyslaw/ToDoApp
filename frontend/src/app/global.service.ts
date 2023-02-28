import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  public readonly baseApiUrl: string = 'http://localhost:5000/api';
}
