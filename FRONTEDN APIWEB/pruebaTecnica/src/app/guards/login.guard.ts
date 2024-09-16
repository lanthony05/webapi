import { CanActivateFn } from '@angular/router';

export const loginGuard: CanActivateFn = (route, state) => {
  let userLogin = window.localStorage.getItem('userLogin');
  let userRole = window.localStorage.getItem('userRole');
  if( localStorage.length > 0 ){
    if(userLogin === undefined || userRole === undefined) {
      return false;
    }
  } else {
    return false;
  }
  return true;
};
