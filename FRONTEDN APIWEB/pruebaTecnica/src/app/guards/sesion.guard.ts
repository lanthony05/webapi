import { CanActivateFn } from '@angular/router';

export const sesionGuard: CanActivateFn = (route, state) => {
  let userLogin = window.localStorage.getItem('userLogin');
  let userRole = window.localStorage.getItem('userRole');
  if( localStorage.length > 0 ){
    if(userLogin === null || userRole === null) {
      return true;
    }
  } else {
    return true;
  }
  return false;
};
