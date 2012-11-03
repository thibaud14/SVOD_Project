class VideoFixColumnName < ActiveRecord::Migration
  def up
    rename_column :videos, :type, :type_video
  end

  def down
  end
end
