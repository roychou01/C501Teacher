--inner join 的第二種寫法
-------------------------------
  select *
  from 供應商 as s inner join  
  (產品類別 as pt inner join  
  (產品資料 as p inner join  
  (貨運公司 as d inner join 
  (員工 as e inner join  
  (客戶 as c inner join 
  (訂單明細 as od inner join 
  訂單資料 as o 
  on od.訂單號碼=o.訂單號碼) 
  on c.客戶編號=o.客戶編號) 
  on e.員工編號=o.員工編號)
  on d.貨運公司編號=o.送貨方式)
  on p.產品編號=od.產品編號)
  on pt.類別編號=p.類別編號)
  on s.供應商編號=p.供應商編號
  ---------------------------------
  --inner join 第三種寫法
--自然合併法、隱含合併法
  select *
  from 供應商 as s ,產品類別 as pt, 產品資料 as p, 貨運公司 as d, 員工 as e, 客戶 as c, 訂單明細 as od , 訂單資料 as o
  where od.訂單號碼=o.訂單號碼 and c.客戶編號=o.客戶編號 and  e.員工編號=o.員工編號 and  d.貨運公司編號=o.送貨方式 and
  p.產品編號=od.產品編號 and   pt.類別編號=p.類別編號 and  s.供應商編號=p.供應商編號

