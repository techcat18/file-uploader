import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NotifierService } from 'src/app/notifier/data-access/notifier.service';
import { BlobService } from '../../data-access/blob.service';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.scss']
})
export class FileUploaderComponent implements OnInit {
  @ViewChild("fileInput")
  fileInput!: ElementRef;

  form!: FormGroup;
  formData: FormData | null = new FormData();
  chosenFile!: File | null;

  constructor(
    private fb: FormBuilder,
    private blobService: BlobService,
    private notifierService: NotifierService,
    private translateService: TranslateService
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

  onFileDropped(files: any){
    if (files){
      let extension = files[0].name.split('.')[1];

      if (extension.toLowerCase() == 'docx'){
        this.onFileChange(files);
      }
    }
  }

  onFileChange(files: FileList | null){
    if (files){
      this.formData = new FormData();
      this.chosenFile = files[0];
      this.formData?.set("file", files[0]);
      this.form.get("file")?.setValue(this.formData);
    }
  }

  onResetFile(){
    this.chosenFile = null;
    this.fileInput.nativeElement.value = "";
    this.formData = null;
    this.form.get("file")?.setValue(this.formData);
  }

  onSubmit(){
    console.log(this.form.value);
    if (this.form.valid){
      this.formData?.set("email", this.email?.value);
      this.uploadBlob();
    }
  }

  uploadBlob(){
    this.blobService.uploadBlob(this.formData!).subscribe(_ => {
      this.onResetFile();
      this.notifierService.showNotification('fileUploadedMessage', 'SUCCESS');
    }, err => {
      this.notifierService.showNotification('somethingWentWrongMessage', 'ERROR');
    })
  }
}
