class CreateVideos < ActiveRecord::Migration
  def change
    create_table :videos do |t|
      t.string :thumbnail_url
      t.string :type
      t.string :title
      t.date :year
      t.integer :duration
      t.string :country
      t.string :video_url
      t.string :bo_url
      t.string :synopsis
      t.integer :position
      t.string :tagline
      t.integer :season

      t.timestamps
    end
  end
end
