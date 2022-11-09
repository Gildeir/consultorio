using AutoMapper;
using Consultorio.Context;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ConsultorioContext _context;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, ConsultorioContext context, IMapper mapper)
        {
            _pacienteRepository = repository;
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _pacienteRepository.GetPacientesAsync();



            return Ok(pacientes);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetPacientesByIdAsync(id);

            var pacienteRetorno = _mapper.Map<PacienteDetalhesDto>(paciente);

            return pacienteRetorno is not null ?
                Ok(pacienteRetorno) :
                BadRequest("Paciente não encontrado");
        }

        [HttpPost("Criar")]
        public async Task<ActionResult> Post(PacienteAdicionarDTO paciente)
        {
            if (paciente is null) return BadRequest("Dados invalidos");

            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);

            _pacienteRepository.Add(pacienteAdicionar);

            return await _pacienteRepository.SaveChangesAsync()
                ? Ok("Paciente adicionado com sucesso")
                : BadRequest("Erro ao salvar paciente");
        }

        //Aceita passar apenas uma propriedade
        [HttpPut("update-hand-mapper")]
        public async Task<IActionResult>Put(int Id, PacienteAtualizarDTO paciente)
        {
            if (Id <= 0) return BadRequest("Usuário não informado");
            
            var pacienteBanco = await _pacienteRepository.GetPacientesByIdAsync(Id);

            var pacienteList = _pacienteRepository.GetPacienteListById(Id);

            List<PacienteAtualizarDTO> updatePacienteDto = new();

            foreach (var item in pacienteList)
            {
                updatePacienteDto.Add(new PacienteAtualizarDTO
                {
                    Nome = string.IsNullOrWhiteSpace(paciente.Nome) ? pacienteBanco.Nome : paciente.Nome,
                    Email = string.IsNullOrWhiteSpace(paciente.Email) ? pacienteBanco.Email : paciente.Email,
                    Celular = string.IsNullOrWhiteSpace(paciente.Celular) ? pacienteBanco.Celular : paciente.Celular,
                    Cpf = string.IsNullOrWhiteSpace(paciente.Cpf) ? pacienteBanco.Cpf : paciente.Cpf,
                });
            }

            foreach (var item in updatePacienteDto)
            {
                pacienteBanco.Nome = item.Nome;
                pacienteBanco.Cpf = item.Cpf;
                pacienteBanco.Celular = item.Celular;
                pacienteBanco.Email = item.Email;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Paciente atualizado com sucesso");
            }
            catch (System.Exception)
            {
                BadRequest("Erro ao atualizar o paciente");
                throw;
            }
        }


        //Aceita propriedades nulas no corpo da requisição
        [HttpPut("update-automapper")]
        public async Task<IActionResult> UpdateFullClass(int Id, PacienteAtualizarDTO paciente)
        {
            if (Id <= 0) return BadRequest("Usuário não informado");

            var pacienteBanco = await _pacienteRepository.GetPacientesByIdAsync(Id);
            
            var pacienteAtualizar = _mapper.Map(paciente, pacienteBanco);

            try
            {
                _pacienteRepository.Update(pacienteAtualizar);

            }
            catch (Exception)
            {
                throw new Exception("Paciente não atualizado");
            }

            return Ok("Paciente atualizado com sucesso");
                
        }

        [HttpDelete("deletar-paciente")]
        public async Task<IActionResult> DeletePaciente(int Id)
        {
            if (Id <= 0) return BadRequest("Usuário não informado");

            var pacienteDeletar = await _pacienteRepository.GetPacientesByIdAsync(Id);

            if (pacienteDeletar == null)
                return NotFound("Paciente não encontrado");

            _pacienteRepository.Delete(pacienteDeletar);

            return Ok("Paciente deletado com sucesso");

        }
    }
}
