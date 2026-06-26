export interface TodayTask {
  routineId: string;
  title: string;
  icon: string;
  starReward: number;
  done: boolean;
}

export interface TodayPlan {
  childId: string;
  date: string;
  streak: number;
  starsToday: number;
  completionPercent: number;
  tasks: TodayTask[];
}

export interface RoutineCompletion {
  routineId: string;
  completed: boolean;
  starsAwarded: number;
  currentStreak: number;
}
