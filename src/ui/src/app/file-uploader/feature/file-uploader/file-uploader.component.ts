import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UploadBlobModel } from 'src/app/models/uploadBlobModel';
import { BlobService } from '../../data-access/blob.service';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.scss']
})
export class FileUploaderComponent implements OnInit {
  form!: FormGroup;
  formData: FormData = new FormData();

  constructor(
    private fb: FormBuilder,
    private blobService: BlobService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  get email(){
    return this.form.get("email");
  }

  initializeForm(){
    this.form = this.fb.group({
      file: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]]
    })
  }

  onFileChange(files: FileList | null){
    if (files){
      this.formData.set("file", files[0]);
      this.form.get("file")?.setValue(this.formData);
    }
  }

  onSubmit(){
    console.log(this.form.value);
    if (this.form.valid){
      this.formData.set("email", this.email?.value);
      this.uploadBlob();
    }
  }

  uploadBlob(){
    this.blobService.uploadBlob(this.formData).subscribe(b => {

    })
  }
}
