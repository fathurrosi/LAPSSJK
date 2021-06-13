create procedure [dbo].[sp_GetTable]
@id_template int 
as
begin

--*********** bikin kolom dinamis ******
DECLARE  @Query AS NVARCHAR(MAX) , @FieldName AS NVARCHAR(MAX) = null;
SELECT	@FieldName = CASE WHEN @FIELDNAME IS NULL THEN '' ELSE @FieldName + ', ' END + '[' + REPLACE(column_alias,']',']]') + ']'
FROM	[tbl_post_list_field]  where id_template =@id_template order by  column_seq
--*********** bikin kolom dinamis ******
		
select @QUERY = CONCAT( ' SELECT	row_index, ', @FieldName,
'FROM(
	select d.row_index, h.column_alias, value_field from [tbl_post_list_field] h
	join [tbl_post_list_value] d on d.id_field = h.id
	where h.id_template = ', @id_template, '
)src PIVOT (max(value_field) for column_alias in ( ' , @FieldName ,

' )) piv ')

EXEC(@QUERY)

end
GO


