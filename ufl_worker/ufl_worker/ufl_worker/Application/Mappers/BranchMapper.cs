using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class BranchMapper
    {
        public static BranchDto ToDto(this Branch branch)
        {
            return new BranchDto
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                BranchCellphone = branch.BranchCellphone,
                BusinessId = branch.BusinessId,
                IsDeleted = branch.IsDeleted
            };
        }

        public static Branch ToEntity(this BranchDto dto)
        {
            return new Branch
            {
                Id = dto.Id,
                BranchName = dto.BranchName,
                BranchCellphone = dto.BranchCellphone,
                BusinessId = dto.BusinessId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
