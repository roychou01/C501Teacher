SELECT          訂單資料.訂單號碼, 客戶.公司名稱, 客戶.連絡人, 訂單資料.訂單日期, 訂單資料.要貨日期, 訂單資料.送貨日期, 
                            產品類別.類別名稱, 產品資料.產品, round( sum(訂單明細.單價*訂單明細.數量*(1-訂單明細.折扣)),0) as 小計 
FROM              訂單資料 INNER JOIN
                            客戶 ON 訂單資料.客戶編號 = 客戶.客戶編號 INNER JOIN
                            訂單明細 ON 訂單資料.訂單號碼 = 訂單明細.訂單號碼 INNER JOIN
                            員工 ON 訂單資料.員工編號 = 員工.員工編號 INNER JOIN
                            產品資料 ON 訂單明細.產品編號 = 產品資料.產品編號 INNER JOIN
                            供應商 ON 產品資料.供應商編號 = 供應商.供應商編號 INNER JOIN
                            產品類別 ON 產品資料.類別編號 = 產品類別.類別編號 INNER JOIN
                            貨運公司 ON 訂單資料.送貨方式 = 貨運公司.貨運公司編號
						group by 訂單資料.訂單號碼, 客戶.公司名稱, 客戶.連絡人, 訂單資料.訂單日期, 訂單資料.要貨日期, 訂單資料.送貨日期, 
                            產品類別.類別名稱, 產品資料.產品
------------------------------------
SELECT          客戶.*
FROM              客戶
------------------------------------


