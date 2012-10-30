class CreateVideoGenres < ActiveRecord::Migration
  def change
    create_table :video_genres do |t|

      t.timestamps
    end
  end
end
