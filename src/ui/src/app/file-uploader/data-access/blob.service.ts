import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlobService {

  constructor(private http: HttpClient) { }

  uploadBlob(model: FormData){
    return this.http.post(environment.apiUrl + "blobs", model, {
      reportProgress: true,
      observe: "events"
    });
  }
}
