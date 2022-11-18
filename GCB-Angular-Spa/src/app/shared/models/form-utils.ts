import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { FormError } from './form-error';

export class FormUtils extends FormError {
  public form: FormGroup;

  constructor() {
    super();

    this.form = new FormGroup({});
  }

  public assign(value: any) {
    const formValue = this.formValue();
    Object.keys(formValue).forEach(key => {
      if (key in value) {
        value[key] = formValue[key];
        console.log(key, value);
      }
    });
  }

  public assignTo(from: any, to: any) {
    Object.keys(from).forEach(key => {
      to[key] = from[key];
    });
  }

  public getControl(controlName: string): FormControl {
    return this.form?.get(controlName) as FormControl;
  }

  public getGroup(controlName: string): FormGroup | null {
    return this.form?.get(controlName) as FormGroup;
  }

  public getGroupAndControl(groupName: string, controlName: string): AbstractControl | null | undefined {
    return (this.getGroup(groupName))?.get(controlName);
  }

  public getValue(controlName: string): any {
    return this.form?.get(controlName)?.value;
  }

  public disableControl(controlName: string): void {
    this.getControl(controlName)?.disable();
  }

  public hasError(controlName: string, errorName: string) {
    return this.getControl(controlName)?.hasError(errorName);
  }

  public hasGroupError(groupName: string, controlName: string, errorName: string) {
    return this.getGroupAndControl(groupName, controlName)?.hasError(errorName);
  }

  public invalid(controlName: string) {
    return this.getControl(controlName)?.invalid;
  }

  public invalidGroup(groupName: string) {
    return this.getGroup(groupName)?.invalid;
  }

  public validarForm(): boolean {
    this.limparErro();

    this.form?.markAllAsTouched();

    if (this.form?.invalid) {
      this.habilidarBotao();

      this.verificarError();
      return false;
    }

    this.verificarError();
    return true;
  }

  formValue(onlyEnabled = false): any {
    if (this.validarForm()) {
      return onlyEnabled ? this.form.value : this.form.getRawValue();
    }

    return null;
  }
}
