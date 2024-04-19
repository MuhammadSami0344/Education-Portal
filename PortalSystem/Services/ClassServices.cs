using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PortalSystem.Data;
using PortalSystem.Models;
using PortalSystem.Pages;
using PortalSystem.View_Models;
using System.Security.Claims;

namespace PortalSystem.Services
{
    public class ClassServices : IClassServices
    {
        private readonly PortalSystemDb _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public ClassServices(PortalSystemDb context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task AddClass(ClassVm modelVm)
        {
            try
            {
                var classRecord = new TblClass();
                classRecord.ClassName = modelVm.ClassName;
                classRecord.GradeLevel = modelVm.GradeLevel;
                classRecord.Time = modelVm.Time;
                classRecord.TotalSets = modelVm.TotalSets;
                classRecord.RemainingSets = modelVm.TotalSets;
                _context.TblClasses.Add(classRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteClass(int classId)
        {
            try
            {
                var classRecord = _context.TblClasses.Find(classId);
                if (classRecord != null)
                {
                    _context.TblClasses.Remove(classRecord);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ClassVm> EditClass(int classId)
        {
            try
            {

                return await (from c in _context.TblClasses
                              where c.Id == classId
                              select new ClassVm()
                              {
                                  Id = c.Id,
                                  ClassName = c.ClassName,
                                  GradeLevel = c.GradeLevel,
                                  Time = c.Time,
                                  TotalSets = c.TotalSets,
                                  RemainingSets = c.RemainingSets,
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<ClassVm>> GetAll()
        {
            try
            {
                var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authenticationState.User;
                var userId = user.FindFirst(ClaimTypes.Sid)?.Value;
                return await (from c in _context.TblClasses
                              orderby c.Id descending
                              select new ClassVm()
                              {
                                  Id = c.Id,
                                  ClassName = c.ClassName,
                                  GradeLevel = c.GradeLevel,
                                  Time = c.Time,
                                  TotalSets = c.TotalSets,
                                  RemainingSets = c.RemainingSets,
                                  ChangeEnrollStatus = _context.TblEnrolledUsers.Any(e => e.ClassId == c.Id && e.UserId == Convert.ToInt32(userId) && e.EnrollStatus == true),
                              }).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<ClassVm>> GetEnrolledUsers(int classId)
        {
            try
            {

                return await (from c in _context.TblClasses
                              join e in _context.TblEnrolledUsers on classId equals e.ClassId
                              where c.Id == classId && e.EnrollStatus == true
                              orderby e.UserEnrolledDate descending
                              select new ClassVm()
                              {
                                  Id = c.Id,
                                  ClassName = c.ClassName,
                                  GradeLevel = c.GradeLevel,
                                  Time = c.Time,
                                  TotalSets = c.TotalSets,
                                  RemainingSets = c.RemainingSets,
                                  UserName = e.UserName,
                                  EnrolledDate = e.UserEnrolledDate,

                              }).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateClass(ClassVm modelVm)
        {
            try
            {
                var classRecord = _context.TblClasses.Find(modelVm.Id);
                classRecord.ClassName = modelVm.ClassName;
                classRecord.GradeLevel = modelVm.GradeLevel;
                classRecord.Time = modelVm.Time;
                classRecord.RemainingSets = modelVm.TotalSets;
                classRecord.TotalSets = modelVm.TotalSets;
                _context.TblClasses.Update(classRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
