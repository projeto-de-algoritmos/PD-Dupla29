using FitnessConsole.App;
using FitnessConsole.CORE.Entities;
using FitnessConsole.Infrastructure.REPOSITORIES;
using FitnessConsole.Infrastructure.Storage;
using FitnessConsole.Services;
using FitnessConsole.SERVICES;

try
{
    WeightIntervalScheduling weightIntervalScheduling = new WeightIntervalScheduling();
    JsonStorage<Attendance> jsonStorage = new JsonStorage<Attendance>();
    AttendanceRepository attendanceRepository = new AttendanceRepository(jsonStorage);
    AttendanceService attendanceService = new AttendanceService(attendanceRepository,weightIntervalScheduling);
    AppConsole appConsole = new AppConsole(attendanceService);
    await appConsole.GetDayScheduleAsync();
}
catch (System.Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}