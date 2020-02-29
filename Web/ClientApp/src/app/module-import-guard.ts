import {Error} from 'tslint/lib/error';

export function throwIfAlreadyLoaded(parentModule: any, moduleName: string) {
  if (parentModule) {
    throw new Error('${modulename} has already been loaded. Import Core modules in the AppModule only.');
  }
}