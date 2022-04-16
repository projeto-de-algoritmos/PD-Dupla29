using FitnessConsole.App;
using FitnessConsole.CORE.Entities;
using FitnessConsole.Infrastructure.REPOSITORIES;
using FitnessConsole.Infrastructure.Storage;
using FitnessConsole.Services;

JsonStorage<Attendance> jsonStorage = new JsonStorage<Attendance>();
AttendanceRepository attendanceRepository = new AttendanceRepository(jsonStorage);
AttendanceService attendanceService = new AttendanceService(attendanceRepository);
AppConsole appConsole = new AppConsole(attendanceService);
await appConsole.GetDayScheduleAsync();