import { Room } from './Room';

export interface BedWithRoom {
  idbed: number;
  idroom: number;
  name: string;
  idroomNavigation: Room;
}
