﻿using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.APIModels
{
    //9.1.3 在APIModels資料夾新增PetAdoptionData.cs類別檔
    public class PetAdoptionData
    {

        [Display(Name = "資料編號")]
        public int animal_id { get; set; }
        public string animal_subid { get; set; }
        public int animal_area_pkid { get; set; }
        public int animal_shelter_pkid { get; set; }
        public string animal_place { get; set; }
        public string animal_kind { get; set; }
        public string animal_Variety { get; set; }
        public string animal_sex { get; set; }
        public string animal_bodytype { get; set; }
        public string animal_colour { get; set; }
        public string animal_age { get; set; }
        public string animal_sterilization { get; set; }
        public string animal_bacterin { get; set; }
        public string animal_foundplace { get; set; }
        public string animal_title { get; set; }
        public string animal_status { get; set; }
        public string animal_remark { get; set; }
        public string animal_caption { get; set; }
        public string animal_opendate { get; set; }
        public string animal_closeddate { get; set; }
        public string animal_update { get; set; }
        public string animal_createtime { get; set; }
        public string shelter_name { get; set; }
        public string album_file { get; set; }
        public string album_update { get; set; }
        public string cDate { get; set; }
        public string shelter_address { get; set; }
        public string shelter_tel { get; set; }
    }

}
