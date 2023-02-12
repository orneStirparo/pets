import { Validator } from 'fluentvalidation-ts';

export class RegistrationModel {
  public firstName!: string;
  public lastName!: string;  
  public email!: string;
  public password!: string;
  public confirmPassword!: string;
}

export class RegistrationModelValidator extends Validator<RegistrationModel> {
  constructor() {
    super();

    this.ruleFor('firstName')
    .notEmpty()
    .withMessage('First name is required')

    this.ruleFor('lastName')
    .notEmpty()
    .withMessage('Last name is required')

    this.ruleFor('email')
      .notEmpty()
      .withMessage('Email is required')
      .emailAddress()
      .withMessage('Invalid email address');

    this.ruleFor('password')
      .notEmpty()
      .withMessage('Password is required')
      .minLength(8)
      .withMessage('Password must be at least 8 characters long');

    this.ruleFor('confirmPassword')
      .notEmpty()
      .withMessage('Confirm password is required')
  }
}
