using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace RoboApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoboController : Controller
    {
        private readonly ICabecaService _cabecaService;
        private readonly IBracoEsquerdoService _bracoEsquerdo;
        private readonly IBracoDireitoService _bracoDireito;
        public RoboController(ICabecaService cabecaService, IBracoEsquerdoService bracoEsquerdo, IBracoDireitoService bracoDireito)
        {
            _cabecaService = cabecaService;
            _bracoEsquerdo = bracoEsquerdo;
            _bracoDireito = bracoDireito;
        }

        #region Cabeça
        [HttpGet]
        [Route("Cabeca/RotacaoDaCabeca")]
        public ActionResult ObterPosicaoCabeca()
        {
            var result = (RotacaoCabeca)_cabecaService.rotacao;
            return Ok(result.ToString());
        }

        [HttpPut]
        [Route("Cabeca/GirarCabeca/{posicao}")]
        public ActionResult GirarCabeca(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _cabecaService.GirarCabeca(posicao);
            return Ok(result);
        }

        [HttpPut]
        [Route("Cabeca/InclinarCabeca/{posicao}")]
        public ActionResult InclinarCabeca(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _cabecaService.InclinarCabeca(posicao);
            return Ok(result);
        }

        #endregion

        #region Braço Esquerdo
        
        [HttpGet]
        [Route("BracoEsquerdo/PosicaoDoCotovelo")]
        public ActionResult ObterPosicaoCotoveloEsquerdo()
        {
            var result = (ContracaoCotovelo)_bracoEsquerdo.Cotovelo;
            return Ok(result.ToString());
        }
        [HttpGet]
        [Route("BracoEsquerdo/PosicaoDoPulso")]
        public ActionResult ObterPosicaoPulsoEsquerdo()
        {
            var result = (RotacaoPulso)_bracoEsquerdo.Pulso;
            return Ok(result.ToString());
        }
        [HttpPut]
        [Route("BracoEsquerdo/GirarPulso/{posicao}")]
        public ActionResult GirarPulsoEsquerdo(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _bracoEsquerdo.GirarPulso(posicao);
            return Ok(result);
        }
        [HttpPut]
        [Route("BracoEsquerdo/ContrairCotovelo/{posicao}")]
        public ActionResult ContrairCotoveloEsquerdo(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _bracoEsquerdo.ContrairCotovelo(posicao);
            return Ok(result);
        }

        #endregion

        #region Braço Direito

        [HttpGet]
        [Route("BracoDireito/PosicaoDoCotovelo")]
        public ActionResult ObterPosicaoCotoveloDireito()
        {
            var result = (ContracaoCotovelo)_bracoDireito.Cotovelo;
            return Ok(result.ToString());
        }
        [HttpGet]
        [Route("BracoDireito/PosicaoDoPulso")]
        public ActionResult ObterPosicaoPulsoDireito()
        {
            var result = (RotacaoPulso)_bracoDireito.Pulso;
            return Ok(result.ToString());
        }
        [HttpPut]
        [Route("BracoDireito/GirarPulso/{posicao}")]
        public ActionResult GirarPulsoDireito(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _bracoDireito.GirarPulso(posicao);
            return Ok(result);
        }
        [HttpPut]
        [Route("BracoDireito/ContrairCotovelo/{posicao}")]
        public ActionResult ContrairCotoveloDireito(string posicao)
        {
            if (posicao == String.Empty)
            {
                return BadRequest();
            }
            var result = _bracoDireito.ContrairCotovelo(posicao);
            return Ok(result);
        }

        #endregion
    }
}
