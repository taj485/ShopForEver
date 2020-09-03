import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ImageFile } from '../models/imagefile';
import { HttpClient, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'image-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.css']
})
export class ImageUploaderComponent implements OnInit {

  public message: string;
  public progress: number;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  public uploadFile(files) {
    if (files.length === 0)
      return

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);

    this.http.post('https://localhost:44312/api/ManageItem/UploadItem', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if(event.type === HttpEventType.Response){
          this.message = 'Upload success';
          this.onUploadFinished.emit(event.body);
        }
      })
  }
}
