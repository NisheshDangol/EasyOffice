using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Easy.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Easy.Services.Services;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Extensions.Configuration;
using Easy.Services.Interface;

namespace Easy.Services.Services
{
    public class AssetService : IAssetInterface
    {
        private IConfiguration _config;
        public AssetService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<AssetRes> AdminAsset(AssetAdminReq req)
        {
            AssetRes res = new AssetRes();
            try
            {
                //var param = req.Specification;
                //string jsonstring = JsonConvert.SerializeObject(req);
                string xmlnode = XMLConverter.GetXMLFromObject(req.Specification);
                string sql = "sp_admin_asset";
                var parameters = new DynamicParameters();
                //parameters.Add("@flag", "createattendance");
                parameters.Add("@comid", req.ComID);
                parameters.Add("@staffid", req.StaffID);
                parameters.Add("@vendorid", req.VendorID);
                parameters.Add("@name", req.Name);
                parameters.Add("@description", req.Description);
                parameters.Add("@assettype", req.AssetType);
                if (!string.IsNullOrEmpty(req.Image))
                {
                    var img = Convert.FromBase64String(req.Image);
                    var imgname = DateTime.Now.Ticks;
                    Image image = Image.FromStream(new MemoryStream(img));
                    if (!Directory.Exists(_config["AssetsPath:domain"] + "assetimg"))
                    {
                        Directory.CreateDirectory(_config["AssetsPath:domain"] + "assetimg");
                    }
                    image.Save(_config["AssetsPath:domain"] + "assetimg\\" + imgname + ".jpg", ImageFormat.Jpeg);
                    parameters.Add("@image", imgname + ".jpg");
                }
                parameters.Add("@expirydate", req.ExpiryDate);
                parameters.Add("@noofitem", req.NoOfItem);
                parameters.Add("@quality", req.Quality);
                parameters.Add("@type", req.BuyInf.Type);
                parameters.Add("@date", req.BuyInf.Date);
                parameters.Add("@perprice", req.BuyInf.PerPrice);
                parameters.Add("@branchid", req.BranchID);
                parameters.Add("@fiscalid", req.FiscalID);
                parameters.Add("@assetid", req.AssetID);
                parameters.Add("@status", req.Status);
                parameters.Add("@isexpired", req.IsExpired);
                parameters.Add("@specification", xmlnode);
                parameters.Add("@imgurl", _config["AssetsPath:path"]);
                parameters.Add("@flag", req.Flag);

                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.AssetLst = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = 500;
            }
            return res;
        }

        public async Task<AssetRes> AdminAssetVendor(AssetVendorReq req)
        {
            AssetRes res = new AssetRes();
            try
            {
                string sql = "sp_admin_vendor";
                var parameters = new DynamicParameters();
                parameters.Add("@comid", req.ComID);
                parameters.Add("@staffid", req.StaffID);
                parameters.Add("@vendorid", req.VendorID);
                parameters.Add("@name", req.Name);
                parameters.Add("@address", req.Address);
                parameters.Add("@contact", req.Contact);
                parameters.Add("@contactperson", req.ContactPerson);
                parameters.Add("@pan", req.PAN);
                parameters.Add("@branchid", req.BranchID);
                parameters.Add("@fiscalid", req.FiscalID);
                parameters.Add("@status", req.Status);
                parameters.Add("@flag", req.Flag);

                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.AssetLst = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = 500;
            }
            return res;
        }
    }
}
