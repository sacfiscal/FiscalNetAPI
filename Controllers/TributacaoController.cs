using FiscalNet.Implementacoes.COFINS;
using FiscalNet.Implementacoes.Icms;
using FiscalNet.Implementacoes.IPI;
using FiscalNet.Implementacoes.PIS;
using Microsoft.AspNetCore.Mvc;
using SACFiscalIO.Tributacao.ViewModels.Cofins;
using SACFiscalIO.Tributacao.ViewModels.Icms;
using SACFiscalIO.Tributacao.ViewModels.Ipi;
using SACFiscalIO.Tributacao.ViewModels.Pis;

namespace SACFiscalIO.Tributacao.Controllers
{
    [ApiController]
    public class TributacaoController : ControllerBase
    {

        #region ICMS Próprio
        /// <summary>
        /// Método para calcular a base do ICMS Próprio
        /// </summary>        
        [HttpPost("/api/v1/tributacao/base-icms-proprio")]
        public async Task<IActionResult> CalcularBaseIcmsProprio(BaseIcmsProprioViewModel baseIcms)
        {
            try
            {
                foreach (ItemBaseIcmsProprio item in baseIcms.Itens)
                {
                    if(item.pRedBc > 0)
                    {
                        BaseReduzidaIcmsProprio _baseIcms = new BaseReduzidaIcmsProprio(item.vProd,
                        item.vFrete,
                        item.vSeg,
                        item.vOutro,
                        item.vDesc,
                        item.pRedBc,
                        item.vIpi);

                        item.vBC = _baseIcms.CalcularBaseReduzidaIcmsProprio();
                    } else
                    {
                        BaseIcmsProprio _baseIcms = new BaseIcmsProprio(item.vProd,
                        item.vFrete,
                        item.vSeg,
                        item.vOutro,
                        item.vDesc,
                        item.vIpi);

                        item.vBC = _baseIcms.CalcularBaseIcmsProprio();
                    }                                                           
                }

                return Ok(baseIcms);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CST 00
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms00")]
        public async Task<IActionResult> CalcularIcms00(Icms00ViewModel icms00)
        {
            try
            {
                foreach (ItemIcms00 item in icms00.Itens)
                {
                    Icms00 _icms00 = new Icms00(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms);

                    item.vBC = _icms00.BaseIcmsProprio();
                    item.vIcms = _icms00.ValorIcmsProprio();

                    if (item.pFcp > 0)
                    {
                        Fcp fcp = new Fcp(item.vBC, item.pFcp);
                        item.vFcp = fcp.ValorFCP();
                    }
                }

                return Ok(icms00);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CST 20
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms20")]
        public async Task<IActionResult> CalcularIcms20(Icms20ViewModel icms20)
        {
            try
            {
                foreach (ItemIcms20 item in icms20.Itens)
                {
                    Icms20 _icms20 = new Icms20(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms,
                    item.pRedBc);

                    item.vBC = _icms20.BaseReduzidaIcmsProprio();
                    item.vIcms = _icms20.ValorIcmsProprio();
                    item.vIcmsDeson = _icms20.ValorIcmsDesonerado();

                    if (item.pFcp > 0)
                    {
                        Fcp fcp = new Fcp(item.vBC, item.pFcp);
                        item.vBCFcp = item.vBC;
                        item.vFcp = fcp.ValorFCP();
                    }
                }


                return Ok(icms20);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CST 51
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms51")]
        public async Task<IActionResult> CalcularIcms51(Icms51ViewModel icms51)
        {
            try
            {
                foreach (ItemIcms51 item in icms51.Itens)
                {
                    Icms51 _icms51 = new Icms51(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms,
                    item.pRedBc,
                    item.pDif);

                    item.vBC = _icms51.BaseIcmsProprio();
                    item.vIcms = _icms51.ValorIcmsProprio();
                    item.vIcmsOp = _icms51.ValorIcmsOperacao();
                    item.vIcmsDif = _icms51.ValorIcmsDiferido();

                    if (item.pFcp > 0)
                    {
                        Fcp fcp = new Fcp(item.vBC, item.pFcp);
                        item.vBCFcp = item.vBC;
                        item.vFcp = fcp.ValorFCP();
                    }

                    if (item.pFcpDif > 0)
                    {
                        FcpDiferido fcpDif = new FcpDiferido(item.vFcp, item.pFcpDif);
                        item.vFcpDif = fcpDif.ValorFCPDiferido();

                        FCPEfetivo fcpEfet = new FCPEfetivo(item.vFcp, item.vFcpDif);
                        item.vFcpEfet = fcpEfet.ValorFcpEfetivo();
                    }
                }

                return Ok(icms51);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        #region ICMS ST
        /// <summary>
        /// Método para calcular base do ICMS ST
        /// </summary>        
        [HttpPost("/api/v1/tributacao/base-icms-st")]
        public async Task<IActionResult> CalcularBaseIcmsST(BaseIcmsSTViewModel baseIcmsST)
        {
            try
            {
                foreach (ItemBaseIcmsST item in baseIcmsST.Itens)
                {
                    if (item.pRedBc > 0)
                    {
                        BaseReduzidaIcmsProprio _baseIcms = new BaseReduzidaIcmsProprio(item.vProd,
                        item.vFrete,
                        item.vSeg,
                        item.vOutro,
                        item.vDesc,
                        item.pRedBc);

                        item.vBC = _baseIcms.CalcularBaseReduzidaIcmsProprio();
                    }
                    else
                    {
                        BaseIcmsProprio _baseIcms = new BaseIcmsProprio(item.vProd,
                        item.vFrete,
                        item.vSeg,
                        item.vOutro,
                        item.vDesc);

                        item.vBC = _baseIcms.CalcularBaseIcmsProprio();
                    }


                    if (item.pRedBcST > 0)
                    {
                        BaseReduzidaIcmsST _baseIcmsST = new BaseReduzidaIcmsST(item.vBC,
                        item.pMVAST,
                        item.pRedBcST,
                        item.vIpi);

                        item.vBCST = _baseIcmsST.CalcularBaseReduzidaIcmsST();
                    }
                    else
                    {
                        BaseIcmsST _baseIcmsST = new BaseIcmsST(item.vBC, item.pMVAST, item.vIpi);
                        item.vBCST = _baseIcmsST.CalcularBaseIcmsST();
                    }                                        
                }

                return Ok(baseIcmsST);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }


        /// <summary>
        /// Método para calcular Tributação ICMS CST 10
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms10")]
        public async Task<IActionResult> CalcularIcms10(Icms10ViewModel icms10)
        {
            try
            {
                foreach (ItemIcms10 item in icms10.Itens)
                {
                    Icms10 _icms10 = new Icms10(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms,
                    item.pIcmsST,
                    item.pMVAST,
                    item.pRedBcST);

                    item.vBC = _icms10.BaseIcmsProprio();
                    item.vIcms = _icms10.ValorIcmsProprio();
                    item.vBCST = _icms10.BaseIcmsST();
                    item.vIcmsST = _icms10.ValorIcmsST();
                    item.vIcmsSTDeson = _icms10.ValorICMSSTDesonerado();

                    if (item.pFcp > 0)
                    {
                        Fcp fcp = new Fcp(item.vBC, item.pFcp);
                        item.vBCFcp = item.vBC;
                        item.vFcp = fcp.ValorFCP();
                    }

                    if (item.pFcpST > 0)
                    {
                        FcpST fcpST = new FcpST(item.vBCST, item.pFcpST);
                        item.vBCFcpST = item.vBCST;
                        item.vFcpST = fcpST.ValorFCPST();
                    }
                }

                return Ok(icms10);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CST 30
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms30")]
        public async Task<IActionResult> CalcularIcms30(Icms30ViewModel icms30)
        {
            try
            {
                foreach (ItemIcms30 item in icms30.Itens)
                {
                    Icms30 _icms30 = new Icms30(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms,
                    item.pIcmsST,
                    item.pMVAST,
                    item.pRedBcST);

                    item.vBCST = _icms30.BaseIcmsST();
                    item.vIcmsST = _icms30.ValorIcmsST();
                    item.vIcmsDeson = _icms30.ValorIcmsDesonerado();

                    if (item.pFcpST > 0)
                    {
                        FcpST fcpST = new FcpST(item.vBCST, item.pFcpST);
                        item.vBCFcpST = item.vBCST;
                        item.vFcpST = fcpST.ValorFCPST();
                    }
                }

                return Ok(icms30);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CST 70
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms70")]
        public async Task<IActionResult> CalcularIcms70(Icms70ViewModel icms70)
        {
            try
            {
                foreach (ItemIcms70 item in icms70.Itens)
                {
                    Icms70 _icms70 = new Icms70(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vIpi,
                    item.vDesc,
                    item.pIcms,
                    item.pIcmsST,
                    item.pMVAST,
                    item.pRedBc,
                    item.pRedBcST);

                    item.vBC = _icms70.BaseIcmsProprio();
                    item.vIcms = _icms70.ValorIcmsProprio();
                    item.vIcmsDeson = _icms70.ValorIcmsProprioDesonerado();
                    item.vBCST = _icms70.BaseIcmsST();
                    item.vIcmsST = _icms70.ValorIcmsST();
                    item.vIcmsSTDeson = _icms70.ValorICMSSTDesonerado();

                    if (item.pFcp > 0)
                    {
                        Fcp fcp = new Fcp(item.vBC, item.pFcp);
                        item.vBCFcp = item.vBC;
                        item.vFcp = fcp.ValorFCP();
                    }

                    if (item.pFcpST > 0)
                    {
                        FcpST fcpST = new FcpST(item.vBCST, item.pFcpST);
                        item.vBCFcpST = item.vBCST;
                        item.vFcpST = fcpST.ValorFCPST();
                    }
                }

                return Ok(icms70);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        #endregion

        #region Simples Nacional
        /// <summary>
        /// Método para calcular Tributação ICMS CSOSN 101
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms101")]
        public async Task<IActionResult> CalcularIcms101(Icms101ViewModel icms101)
        {
            try
            {
                foreach (ItemIcms101 item in icms101.Itens)
                {
                    Icms101 _icms101 = new Icms101(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vDesc,
                    item.pCredSN);

                    item.vBC = _icms101.CalcularBaseIcmsProprio();
                    item.vCredSN = _icms101.ValorCreditoSN();
                }

                return Ok(icms101);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CSOSN 201
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms201")]
        public async Task<IActionResult> CalcularIcms201(Icms201ViewModel icms201)
        {
            try
            {
                foreach (ItemIcms201 item in icms201.Itens)
                {
                    Icms201 _icms201 = new Icms201(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vDesc,
                    item.pIcms,
                    item.pIcmsST,
                    item.pMVAST,
                    item.pCredSN,
                    item.pRedBC,
                    item.pRedBcST);

                    item.vBC = _icms201.CalcularBaseIcmsProprio();
                    item.vIcms = _icms201.ValorIcmsProprio();
                    item.vBCST = _icms201.BaseIcmsST();
                    item.vIcmsST = _icms201.ValorIcmsST();
                    item.vCredSN = _icms201.ValorCreditoSN();

                    if (item.pFcpST > 0)
                    {
                        FcpST fcpST = new FcpST(item.vBCST, item.pFcpST);
                        item.vBCFcpST = item.vBCST;
                        item.vFcpST = fcpST.ValorFCPST();
                    }
                }

                return Ok(icms201);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação ICMS CSOSN 202 e 203
        /// </summary>        
        [HttpPost("/api/v1/tributacao/icms202")]
        public async Task<IActionResult> CalcularIcms202(Icms202ViewModel icms202)
        {
            try
            {
                foreach (ItemIcms202 item in icms202.Itens)
                {
                    Icms202_203 _icms202 = new Icms202_203(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vDesc,
                    item.pIcms,
                    item.pIcmsST,
                    item.pMVAST,
                    item.pRedBC,
                    item.pRedBcST);

                    item.vBC = _icms202.CalcularBaseIcmsProprio();
                    item.vIcms = _icms202.ValorIcmsProprio();
                    item.vBCST = _icms202.BaseIcmsST();
                    item.vIcmsST = _icms202.ValorIcmsST();

                    if (item.pFcpST > 0)
                    {
                        FcpST fcpST = new FcpST(item.vBCST, item.pFcpST);
                        item.vBCFcpST = item.vBCST;
                        item.vFcpST = fcpST.ValorFCPST();
                    }
                }

                return Ok(icms202);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        #region FCP
        /// <summary>
        /// Método para calcular Tributação do FCP
        /// </summary>        
        [HttpPost("/api/v1/tributacao/fcp")]
        public async Task<IActionResult> CalcularFcp(FcpViewModel fcp)
        {
            try
            {
                foreach (ItemFcp item in fcp.Itens)
                {
                    Fcp _fcp = new Fcp(item.vBCFcp, item.pFcp);

                    item.vFcp = _fcp.ValorFCP();
                }

                return Ok(fcp);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação do FCP-ST
        /// </summary>        
        [HttpPost("/api/v1/tributacao/fcp-st")]
        public async Task<IActionResult> CalcularFcpST(FcpSTViewModel fcpst)
        {
            try
            {
                foreach (ItemFcpST item in fcpst.Itens)
                {
                    FcpST _fcpst = new FcpST(item.vBCFcpST, item.pFcpST);

                    item.vFcpST = _fcpst.ValorFCPST();
                }

                return Ok(fcpst);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação do FCP Diferido
        /// </summary>        
        [HttpPost("/api/v1/tributacao/fcp-diferido")]
        public async Task<IActionResult> CalcularFcpDiferido(FcpDiferidoViewModel fcpDif)
        {
            try
            {
                foreach (ItemFcpDiferido item in fcpDif.Itens)
                {
                    Fcp fcp = new Fcp(item.vBCFcp, item.pFcp);
                    item.vFcp = fcp.ValorFCP();

                    FcpDiferido _fcpDif = new FcpDiferido(item.vFcp, item.pFcpDif);
                    item.vFcpDif = _fcpDif.ValorFCPDiferido();
                }

                return Ok(fcpDif);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação do FCP Efetivo
        /// </summary>        
        [HttpPost("/api/v1/tributacao/fcp-efetivo")]
        public async Task<IActionResult> CalcularFcpEfetivo(FcpEfetivoViewModel fcpEfet)
        {
            try
            {
                foreach (ItemFcpEfetivo item in fcpEfet.Itens)
                {
                    Fcp fcp = new Fcp(item.vBCFcp, item.pFcp);
                    item.vFcp = fcp.ValorFCP();

                    FcpDiferido _fcpDif = new FcpDiferido(item.vFcp, item.pFcpDif);
                    item.vFcpDif = _fcpDif.ValorFCPDiferido();

                    FCPEfetivo _fcpEfet = new FCPEfetivo(item.vFcp, item.vFcpDif);
                    item.vFcpEfet = _fcpEfet.ValorFcpEfetivo();
                }

                return Ok(fcpEfet);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        #region IPI
        /// <summary>
        /// Método para calcular Tributação IPI CST 50 AdValorem
        /// </summary>        
        [HttpPost("/api/v1/tributacao/ipi50-ad")]
        public async Task<IActionResult> CalcularIcms50Ad(Ipi50AdViewModel ipi50Ad)
        {
            try
            {
                foreach (ItemIpi50Ad item in ipi50Ad.Itens)
                {
                    Ipi50AdValorem _ipi50Ad = new Ipi50AdValorem(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.pIpi);

                    item.vBC = _ipi50Ad.CalcularBaseIPI();
                    item.vIpi = _ipi50Ad.ValorIPI();
                }

                return Ok(ipi50Ad);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação IPI CST 50 Alíquota Específica
        /// </summary>        
        [HttpPost("/api/v1/tributacao/ipi50-ae")]
        public async Task<IActionResult> CalcularIcms50Ae(Ipi50AeViewModel ipi50Ae)
        {
            try
            {
                foreach (ItemIpi50Ae item in ipi50Ae.Itens)
                {
                    Ipi50Especifico _ipi50Ae = new Ipi50Especifico(item.qTrib, item.vUnid);

                    item.vIpi = _ipi50Ae.ValorIPI();
                }

                return Ok(ipi50Ae);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        #region PIS
        /// <summary>
        /// Método para calcular Tributação PIS CST 01 e 02
        /// Caso seja enviado o valor de icms, ele será deduzido da base de pis
        /// </summary>        
        [HttpPost("/api/v1/tributacao/pis0102")]
        public async Task<IActionResult> CalcularPis0102(Pis0102ViewModel pis0102)
        {
            try
            {
                foreach (ItemPis0102 item in pis0102.Itens)
                {
                    Pis01_02 _pis0102 = new Pis01_02(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vDesc,
                    item.pPis,
                    item.vIcms);

                    item.vBC = _pis0102.BasePis();
                    item.vPis = _pis0102.ValorPis();

                }

                return Ok(pis0102);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação PIS CST 03
        /// </summary>        
        [HttpPost("/api/v1/tributacao/pis03")]
        public async Task<IActionResult> CalcularPis03(Pis03ViewModel pis03)
        {
            try
            {
                foreach (ItemPis03 item in pis03.Itens)
                {
                    Pis03 _pis03 = new Pis03(item.qTrib, item.vUnid);

                    item.vPis = _pis03.ValorPis();

                }

                return Ok(pis03);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        #region Cofins
        /// <summary>
        /// Método para calcular Tributação Cofins CST 01 e 02
        /// Caso seja enviado o valor de icms, ele será deduzido da base de Cofins
        /// </summary>        
        [HttpPost("/api/v1/tributacao/cofins0102")]
        public async Task<IActionResult> CalcularCofins0102(Cofins0102ViewModel cofins0102)
        {
            try
            {
                foreach (ItemCofins0102 item in cofins0102.Itens)
                {
                    Cofins01_02 _cofins0102 = new Cofins01_02(item.vProd,
                    item.vFrete,
                    item.vSeg,
                    item.vOutro,
                    item.vDesc,
                    item.pCofins,
                    item.vIcms);

                    item.vBC = _cofins0102.BaseCofins();
                    item.vCofins = _cofins0102.ValorCofins();
                }

                return Ok(cofins0102);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        /// <summary>
        /// Método para calcular Tributação Cofins CST 03
        /// </summary>        
        [HttpPost("/api/v1/tributacao/cofins03")]
        public async Task<IActionResult> CalcularCofins03(Cofins03ViewModel cofins03)
        {
            try
            {
                foreach (ItemCofins03 item in cofins03.Itens)
                {
                    Cofins03 _cofins03 = new Cofins03(item.qTrib, item.vUnid);

                    item.vCofins = _cofins03.ValorCofins();
                }

                return Ok(cofins03);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar tributação: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
        #endregion

        /// <summary>
        /// Método para verificar o status da API
        /// </summary>
        [HttpGet("/api/v1/tributacao/status")]
        public async Task<IActionResult> Status()
        {
            return Ok("API ok");
        }

    }
}
